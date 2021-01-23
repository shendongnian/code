    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;
    abstract class Shape
    {
        static readonly Shape[] s_emptyChildren = new Shape[0];
        public Rect BoundingBox;
        public Transform Transform;
        public Shape[] Children = s_emptyChildren;
        public void RenderShape (DrawingContext context)
        {
            context.PushTransform (Transform ?? Transform.Identity);
            try
            {
                OnRenderShape (context);
                foreach (var shape in Children ?? s_emptyChildren)
                {
                    shape.RenderShape (context);
                }
            }
            finally
            {
                context.Pop ();
            }
        }
        protected abstract void OnRenderShape (DrawingContext context);
    }
    sealed class RectangleShape : Shape
    {
        static readonly SolidColorBrush s_defaultBrush = new SolidColorBrush (Colors.Green).FreezeIfNecessary ();
        public Pen Pen;
        public Brush Brush = s_defaultBrush;
        protected override void OnRenderShape (DrawingContext context)
        {
            context.DrawRectangle (Brush, Pen, BoundingBox);
        }
    }
    static class Extensions
    {
        public static Color SetAlpha (this Color value, byte alpha)
        {
            return Color.FromArgb (alpha, value.R, value.G, value.B);
        }
        public static TValue FreezeIfNecessary<TValue>(this TValue value)
            where TValue : Freezable
        {
            if (value != null && value.CanFreeze)
            {
                value.Freeze ();
            }
            return value;
        }
    }
    class RenderShapeControl : FrameworkElement
    {
        public Shape Shape;
        public Transform ShapeTransform;
        protected override void OnRender (DrawingContext drawingContext)
        {
            if (Shape != null)
            {
                try
                {
                    drawingContext.PushTransform (new TranslateTransform (ActualWidth / 2, ActualHeight / 2).FreezeIfNecessary ());
                    drawingContext.PushTransform (ShapeTransform ?? Transform.Identity);
                    Shape.RenderShape (drawingContext);
                }
                finally
                {
                    drawingContext.Pop ();
                    drawingContext.Pop ();
                }
            }
        }
    }
    public class MainWindow : Window
    {
        static readonly int[] s_childCount = new[] { 0, 5, 5, 5, 5, 5 };
        static readonly Brush s_redBrush = new SolidColorBrush (Colors.Red.SetAlpha (0x80)).FreezeIfNecessary ();
        static readonly Brush s_blueBrush = new SolidColorBrush (Colors.Blue.SetAlpha (0x80)).FreezeIfNecessary ();
        static readonly Pen s_redPen = new Pen (Brushes.Red, 2).FreezeIfNecessary ();
        static readonly Pen s_bluePen = new Pen (Brushes.Blue, 2).FreezeIfNecessary ();
        static Shape MakeInnerPart (int level, int index, int count, double outerside, double angle)
        {
            var innerSide = outerside / 3;
            return new RectangleShape
            {
                BoundingBox = new Rect (-innerSide / 2, -innerSide / 2, innerSide, innerSide),
                Pen = index == 0 ? s_bluePen : s_redPen,
                Brush = index == 0 && level > 0 ? s_redBrush : s_blueBrush,
                Children = MakeInnerParts (level - 1, innerSide),
                Transform =
                    new TransformGroup
                    {
                        Children =
                            new TransformCollection
                                {
                                    new TranslateTransform (outerside/2, 0),
                                    new RotateTransform (angle),
                                },
                    }.FreezeIfNecessary (),
            };
        }
        static Shape[] MakeInnerParts (int level, double outerside)
        {
            var count = s_childCount[level];
            return Enumerable
                .Range (0, count)
                .Select (i => MakeInnerPart (level, i, count, outerside, (360.0 * i) / count))
                .ToArray ();
        }
        static RectangleShape MakeComplexShape ()
        {
            return new RectangleShape
            {
                BoundingBox = new Rect (-200, -200, 400, 400),
                Pen = s_redPen,
                Brush = null,
                Children = MakeInnerParts (3, 400),
            };
        }
        static RectangleShape MakeSimpleShape ()
        {
            return
                new RectangleShape
                    {
                        BoundingBox = new Rect (-200, -200, 400, 400),
                        Pen = s_redPen,
                        Brush = null,
                        Children =
                            new Shape[]
                                {
                                    new RectangleShape
                                        {
                                            BoundingBox = new Rect (-40, -40, 40, 40),
                                            Transform = new TranslateTransform (100, 100),
                                        },
                                },
                    };
        }
        readonly DispatcherTimer m_dispatcher;
        readonly DateTime m_start = DateTime.Now;
        readonly RenderShapeControl m_shapeRenderer = new RenderShapeControl ();
        public MainWindow ()
        {
            AddChild (m_shapeRenderer);
            m_dispatcher = new DispatcherTimer (
                TimeSpan.FromSeconds (1 / 60),
                DispatcherPriority.ApplicationIdle,
                OnTimer,
                Dispatcher
                );
            m_dispatcher.Start ();
            m_shapeRenderer.Shape = MakeComplexShape ();
            //m_shapeRenderer.Shape = MakeSimpleShape ();
        }
        void OnTimer (object sender, EventArgs e)
        {
            var diff = DateTime.Now - m_start;
            var phase = (20 * diff.TotalSeconds) % 360.0;
            m_shapeRenderer.ShapeTransform =
                new TransformGroup
                {
                    Children =
                        new TransformCollection
                            {
                                new TranslateTransform (100, 0),
                                new RotateTransform (phase),
                            },
                }.FreezeIfNecessary ();
            m_shapeRenderer.InvalidateVisual ();
        }
    }
    class Program
    {
        [STAThread]
        static void Main (string[] args)
        {
            var mainWindow = new MainWindow ();
            mainWindow.ShowDialog ();
        }
    }
