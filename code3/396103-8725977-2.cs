    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Globalization;
    
    namespace Adorners
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded += (o, e) => 
                {
                    AdornerLayer layer = AdornerLayer.GetAdornerLayer(this.t);
    
                    MyAdorner myAdorner = new MyAdorner(this.t);
    
                    layer.Add(myAdorner);
    
                    this.t.Text = "Modified Value";
                };
            }
        }
    
    
        public class MyAdorner : Adorner
        {
            public static DependencyProperty TextProperty =
                DependencyProperty.Register("Text",
                typeof(string),
                typeof(MyAdorner),
                new PropertyMetadata("Default Text", 
                (o, e) => 
                {
                    ((MyAdorner)o).InvalidateVisual();
                }));
    
            // Be sure to call the base class constructor.
            public MyAdorner(UIElement adornedElement)
                : base(adornedElement)
            {
                this.DataContext = this.AdornedElement;
    
                this.SetUpBindings();
            }
    
            private void SetUpBindings()
            {
                BindingOperations.SetBinding(this,
                   MyAdorner.TextProperty,
                   new Binding()
                   {
                       Path = new PropertyPath("Text"),
                       UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                   });
            }
    
            public string Text
            {
                get { return (string)this.GetValue(MyAdorner.TextProperty); }
                set { this.SetValue(MyAdorner.TextProperty, value); }
            }
            protected override void OnRender(DrawingContext drawingContext)
            {
                Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
    
                drawingContext.DrawText(new FormattedText(this.Text, CultureInfo.CurrentCulture, 
                    FlowDirection.LeftToRight, 
                    new Typeface("Arial"), 
                    20, 
                    Brushes.Black), 
                    new Point(0, 150));
            }
        }
    }
