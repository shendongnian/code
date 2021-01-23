    **Fill ListView :**   
     For(int i=0; i<fileLocationArray.Count();i++)
        {
        System.Windows.Controls.Image imgControl=new System.Windows.Controls.Image();
        BitmapImage imgsrc = new BitmapImage();
       imgsrc.BeginInit();
       imgsrc.UriSource=fileLocationArray[i];
                        imgsrc.EndInit();
        imgControl.source=imgsrc;
        listView.Items.Add(imgControl);
        
        }
        
        **After filling ListView control  create event  listView SelectionChanged**
        **imgContolShow   // this control show selected image**
        
        void listw_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
               imgContolShow.Source = ((System.Windows.Controls.Image)listwiev.SelectedItem).Source;  
            }
