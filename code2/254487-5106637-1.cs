    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;
    
    namespace TestApp
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                _adp.Fill(_tbl);
    
                cmbCities.ItemsSource = ((IListSource)_tbl).GetList();
    
                cmbCities.DisplayMemberPath = "[CategoryName]";
                cmbCities.SelectedValuePath = "[CategoryID]";
    
                DataContext = this;
            }
    
            private void OnClear(object sender, RoutedEventArgs e)
            {
                _tbl.Clear();
            }
    
            private void OnFill(object sender, RoutedEventArgs e)
            {
                _adp.Fill(_tbl);
            }
    
            private DataTable _tbl = new DataTable();
            private SqlDataAdapter _adp = new SqlDataAdapter(@"SELECT [CategoryID],[CategoryName]FROM [Northwind].[dbo].[Categories]", @"Integrated Security=SSPI;Initial Catalog=Northwind;Data Source=AKSHAY-PC\SQLEXPRESS");
    
        }
    }
