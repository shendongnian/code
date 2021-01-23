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
    namespace ColumnSeriesApp
    {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public PetData m_PetData;
		public MainWindow()
		{
			m_PetData = new PetData();
			DataContext = m_PetData;
			InitializeComponent();
		}
		private void m_colserHistogram_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			// Figure out what column we are on and display a popup menu based on the information.
			IInputElement ieMouseOver = e.MouseDevice.DirectlyOver;
			Rectangle rMouseOver = (Rectangle)ieMouseOver;
			string strMouseOverContext= rMouseOver.DataContext.ToString();
			string strMouseOverKey= "";
			foreach (var vKvP in m_PetData)
			{
				if (1 == strMouseOverContext.IndexOf(vKvP.Key))
					strMouseOverKey = vKvP.Key;
			}
			if (!String.IsNullOrEmpty(strMouseOverKey))
				MessageBox.Show("The X value is " + strMouseOverKey);
		}
	}
	public class PetData : Dictionary<string, int>
	{
		public PetData()
		{
			Add("SallyBeagle", 7);
			Add("Cujo", 10);
			Add("DobyDeedle", 11);
			Add("Caramel", 6);
			Add("Boo", 6);
		}
	}
    }
