    //Updated code.
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32;
    
    namespace RegistryUSER
    {
        
    
        public partial class Form1 : Form
        {
            public class RegKeyInfo
            {
                public String SubKeyPath { get; set; }
                public String Name { get; set; }
            }
    
            public Form1()
            {
                InitializeComponent();
                comboBox1.ValueMember = "SubKeyPath";
                comboBox1.DisplayMember = "Name";
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var keys = new List<RegKeyInfo>();
                
                using (RegistryKey ProfileKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList"))
                {
                    foreach (string skName in ProfileKey.GetSubKeyNames())
                    {
                        using (RegistryKey sk = ProfileKey.OpenSubKey(skName))
                        {
                            try
                            {
                                if (!(sk.GetValue("Guid") == null))
                                {
                                    string UserProfile;
                                    string UserProfileKey;
                                    string ProfileValue = null;
                                    string ProfileKeyName = null;
                                    UserProfile = ProfileValue += sk.GetValue("ProfileImagePath");
                                    UserProfileKey = ProfileKeyName += skName;
                                    
                                    RegKeyInfo UserInformation = new RegKeyInfo();
                                    UserInformation.Name = UserProfile;
                                    UserInformation.SubKeyPath = UserProfileKey;
    
                                    UserProfile = UserProfile.Substring(9); //this reduces C:\Users\Home to Home. (0, 8) would have provide C:\Users
    
                                    keys.Add(new RegKeyInfo
                                    {
                                        Name = UserProfile,
                                        SubKeyPath = UserProfileKey
                                    });
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    comboBox1.DataSource = keys;
                }
            }
    
          
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    string result = comboBox1.SelectedValue as string;
                    using (RegistryKey Key = Registry.Users.OpenSubKey(result + @"\Software\Microsoft\Office\14.0\Outlook\OST"))
                        
                        if (Key != null)
                        {
                            int Value = System.Convert.ToInt32(Key.GetValue("NoOST"));
                            if (Value == 3)
                            {
                                MessageBox.Show("yes");
                            }
                            else
                            {
                                MessageBox.Show("no");
                            }
                        }
                        else
                        {
                           MessageBox.Show("not present");
                        }
    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
