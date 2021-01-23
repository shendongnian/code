    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.XPath;
    
    namespace MultipleBoundListBox
    {
        public partial class Form1 : Form
        {
            private static XmlDocument xmlDoc;
            private static XPathNavigator nav;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load("target.xml");
    
                nav = xmlDoc.DocumentElement.CreateNavigator();
    
                nav.MoveToFirstChild();
                var countries = new List<string>();
                countries.Add(nav.LocalName);
    
                while (nav.MoveToNext())
                {
                    countries.Add(nav.LocalName);
                }
    
                listBox1.DataSource = countries;
    
                BindCities(countries[0]);
            }
    
            protected void BindCities(string country)
            {
                nav.MoveToRoot();
                var xpath = "/World/" + country;
                var countryElement = nav.SelectSingleNode(xpath);
                countryElement.MoveToFirstChild();
    
                var cities = new List<string>();
                cities.Add(countryElement.LocalName);
    
                while (countryElement.MoveToNext())
                {
                    cities.Add(countryElement.LocalName);
                }
    
                listBox2.DataSource = cities;
    
                BindDistricts(country, cities[0]);
            }
    
            protected void BindDistricts(string country, string city)
            {
                nav.MoveToRoot();
                var xpath = "/World/" + country + "/" + city;
                var districtElement = nav.SelectSingleNode(xpath);
                districtElement.MoveToFirstChild();
    
                var districts = new List<string>();
                districts.Add(districtElement.LocalName);
    
                while (districtElement.MoveToNext())
                {
                    districts.Add(districtElement.LocalName);
                }
    
                listBox3.DataSource = districts;
            }
    
            private void listBox1_SelectedValueChanged(object sender, EventArgs e)
            {
                BindCities((string)listBox1.SelectedValue);
            }
    
            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                BindDistricts((string)listBox1.SelectedValue, (string)listBox2.SelectedValue);
            }
        }
    }
