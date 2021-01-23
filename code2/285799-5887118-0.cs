    public void seektomediaposition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
    
    string name = Convert.ToString(e.Source.GetType().GetProperty("Name").GetValue(e.Source, null));
    MessageBox.Show(name);
    if(name=="seektomediaposition")
      // whatever is the code
    if(name=="seektomediaposition2")
      // whatever is the code
    
        }
