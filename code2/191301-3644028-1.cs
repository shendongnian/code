    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace MovingPointsSpike
    {
        
        public partial class MainWindow : Window
        {
            private List<Point> m_Points;
            private Random m_Random;
    
            public MainWindow()
            {
                InitializeComponent();
                m_Points=new List<Point>();
                m_Random=new Random();
            }
    
            private void Move_Click(object sender, RoutedEventArgs e)
            {
                Rectangle rectangle;
                Point newPoint;
                int index = GetRandomIndex();
                newPoint = GetRandomPoint();
    
                rectangle =(Rectangle)PointCanvas.Children[index];
                if (index == -1) return;
                Canvas.SetTop(rectangle, newPoint.Y);
                Canvas.SetLeft(rectangle, newPoint.X);
            }
    
            private void Add_Click(object sender, RoutedEventArgs e)
            {
                Point newPoint;
                Rectangle rectangle;
    
                newPoint = GetRandomPoint();
                rectangle = new Rectangle {Width = 4, Height = 4, Fill = Brushes.Red};
                m_Points.Add(newPoint);
                PointCanvas.Children.Add(rectangle);
                Canvas.SetTop(rectangle,newPoint.Y);
                Canvas.SetLeft(rectangle,newPoint.X);
            }
    
            private Point GetRandomPoint()
            {
                int x;
                int y;
                x = m_Random.Next(10, 490);
                y = m_Random.Next(10, 490);
                return new Point(x,y);
            }
    
            private void Remove_Click(object sender, RoutedEventArgs e)
            {
                int index = GetRandomIndex();
                if (index==-1)return;
    
                PointCanvas.Children.RemoveAt(index);
                m_Points.RemoveAt(index);
    
            }
    
            private int GetRandomIndex()
            {
                int index;
                if (m_Points.Count==0) return -1;
                index = m_Random.Next(m_Points.Count - 1);
                return index;
            }
        }
    }
