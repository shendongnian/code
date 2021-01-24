``
public class Whatever 
{
    public string whatevs
    {
     get;
     set;
    }
    public string uhgosh
    {
    get;
    set;
    }
}
        private void Hyplink_hyperlinkbutton_Click(object sender, RoutedEventArgs e)
        {
            Whatever s = new Whatever()
            {
                whatevs = text1_textbox.Text,
                uhgosh = text2_textbox.Text
            };
            this.Frame.Navigate(typeof(BlankPage1), s);
        }
``
this will pass textbox data to other textboxs, and whatever is in them including ints. from there, on the new page, you can use those ints/doubles for things. probably a way to make it better but its what I managed to come up with after.... 6 hours? jeez.
