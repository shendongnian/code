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
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Management.Automation;
    //C:\Program Files (x86)\Reference Assemblies\Microsoft\WindowsPowerShell\v1.0\System.Management.Automation.dll
    
    namespace DataGridTest
    {
        public partial class MainWindow : Window
        {
            string scriptText = @"$quotastat = @()
    $quotastat += new-object psobject -property @{
    	Identity = 1
    	Value = '0.5GB'
    	IssueWarningQuota = '471860 KB'
    	ProhibitSendQuota = '498074 KB'
    	ProhibitSendReceiveQuota = '524288 KB'
    }
    $quotastat += new-object psobject -property @{
    	Identity = 2
    	Value = '1GB (default)'
    	IssueWarningQuota = '943719 KB'
    	ProhibitSendQuota = '996148 KB'
    	ProhibitSendReceiveQuota = '1048576 KB'
    }
    $quotastat";
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void RunGrid1_Click(object sender, RoutedEventArgs e)
            {
                StringBuilder sb = new StringBuilder();
    
                PowerShell psExec = PowerShell.Create();
                psExec.AddScript(scriptText);
    
                Collection<PSObject> results;
                Collection<ErrorRecord> errors;
                results = psExec.Invoke();
                errors = psExec.Streams.Error.ReadAll();
    
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
    
                foreach (PSMemberInfo member in results[0].Members)
                {
                    if (member.MemberType == PSMemberTypes.NoteProperty)
                    {
                        dt.Columns.Add(member.Name, Type.GetType(member.TypeNameOfValue));
                    }
                }
    
                foreach (PSObject result in results)
                {
                    DataRow dr = dt.NewRow();
    
                    foreach (PSPropertyInfo pi in result.Properties)
                    {
                        dr[pi.Name] = pi.Value;
                    }
    
                    dt.Rows.Add(dr);
                }
    
                ds.Tables.Add(dt);
                dg1.DataContext = ds.Tables[0];
            }
    
    
            private void RunGrid2_Click(object sender, RoutedEventArgs e)
            {
                StringBuilder sb = new StringBuilder();
    
                PowerShell psExec = PowerShell.Create();
                psExec.AddScript(scriptText);
    
                Collection<PSObject> results;
                Collection<ErrorRecord> errors;
                results = psExec.Invoke();
                errors = psExec.Streams.Error.ReadAll();
    
                DataGrid outputGrid = new DataGrid()
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                };
    
                DataTable dt = new DataTable();
    
                foreach (PSMemberInfo member in results[0].Members)
                {
                    if (member.MemberType == PSMemberTypes.NoteProperty)
                    {
                        dt.Columns.Add(member.Name, Type.GetType(member.TypeNameOfValue));
                    }
                }
    
                foreach (PSObject result in results)
                {
                    DataRow dr = dt.NewRow();
    
                    foreach (PSPropertyInfo pi in result.Properties)
                    {
                        dr[pi.Name] = pi.Value;
                    }
    
                    dt.Rows.Add(dr);
                }
    
                outputGrid.ItemsSource = dt.DefaultView;
                sv1.Content = outputGrid;
            }
    
        }
    }
