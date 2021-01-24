    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace so_wpf_test_1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var items = new ObservableCollection<Item>();
                for (int i = 1; i <= 50; ++i)
                {
                    items.Add(new Item($"test {i}", $"abcd {i}", $"dcba {i}"));
                }
                dg.ItemsSource = items;
                dg2.ItemsSource = items;
    
                dg.PreviewMouseWheel += Dg_PreviewMouseWheel;
                dg2.PreviewMouseWheel += Dg_PreviewMouseWheel;
            }
    
            private void Dg_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
            {
                var m_dg = sender as DataGrid;
                var scroll = GetScrollViewer(m_dg);
    
                // if scrolling to bottom and beyond...
                if (e.Delta < 0 && scroll.VerticalOffset == scroll.ScrollableHeight)
                {
                    sv.ScrollToVerticalOffset(sv.VerticalOffset - e.Delta);
                }
                // if scrolling to top and beyond...
                else if (e.Delta > 0 && scroll.VerticalOffset == 0)
                {
                    sv.ScrollToVerticalOffset(sv.VerticalOffset - e.Delta);
                }
                else
                {
                    // nothing special: scroll the dg if it is the case (WPF does this automatically)
                }
    
                int idx = 0;
    
                // if scrolling down
                if (e.Delta < 0)
                {
                    // see the sketch
                    idx = dictLastVisible[m_dg] + 1;
                    
                    Debug.WriteLine($"FROM {(m_dg == dg ? 1 : 2)} DOWN {idx}");
                }
                // if scrolling up
                else if (e.Delta > 0)
                {
                    // see the sketch
                    idx = dictFirstVisible[m_dg] - 1;
    
                    Debug.WriteLine($"FROM {(m_dg == dg ? 1 : 2)} UP {idx}");
                }
    
                // if the index does not represent nothing
                if (idx != 0)
                {
                    // transform index to be 0-based
                    --idx;
    
                    // scroll that row into view
                    m_dg.ScrollIntoView(m_dg.Items[idx]);
                }
            }
    
            /// <summary>
            /// Source: https://stackoverflow.com/a/41136328/258462
            /// </summary>
            /// <param name="element"></param>
            /// <returns></returns>
            public static ScrollViewer GetScrollViewer(UIElement element)
            {
                if (element == null) return null;
    
                ScrollViewer retour = null;
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element) && retour == null; i++)
                {
                    if (VisualTreeHelper.GetChild(element, i) is ScrollViewer)
                    {
                        retour = (ScrollViewer)(VisualTreeHelper.GetChild(element, i));
                    }
                    else
                    {
                        retour = GetScrollViewer(VisualTreeHelper.GetChild(element, i) as UIElement);
                    }
                }
                return retour;
            }
    
            Dictionary<DataGrid, int> dictLastVisible = new Dictionary<DataGrid, int>();
            Dictionary<DataGrid, int> dictFirstVisible = new Dictionary<DataGrid, int>();
    
            private void dg_ScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                var dg = (DataGrid)sender;
    
                int idxb = -1, idxe = -1; // b = beginning, e = end; both invalid initially
    
                // from the first row towards the last row
                for (int i = 0; i < dg.Items.Count; i++)
                {
                    var v = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(dg.Items[i]);
    
                    if (v != null)
                    {
                        idxb = i + 1; // compute the beginning row in the viewport
                        break;
                    }
                }
    
                // from the beginning row towards the last row
                for (int i = idxb + 1; i < dg.Items.Count; i++)
                {
                    var v = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(dg.Items[i]);
    
                    if (v == null)
                    {
                        idxe = i - 1 + 1; // compute the end row in the viewport
                        break;
                    }
                }
    
                // store the two indices in two dictionaries
                dictFirstVisible[dg] = idxb;
                dictLastVisible[dg] = idxe;
            }
        }
    
        public class Item
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
    
            public Item(string a, string b, string c)
            {
                A = a;
                B = b;
                C = c;
            }
        }
    }
