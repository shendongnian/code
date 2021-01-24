    //collect list of buttonyes
     var ListButton =Driver.FindElements(By.XPath("//button[contains (text(), 'Yes')]"));
        for(int i=0 ;i<ListButton.Count ;i++ )
        {
            if(ListButton[i].Enabled &&ListButton[i].Displayed )
            {
                ListButton[i].Click ( );
                System.Threading.Thread.Sleep ( 2000 );
            }         
            ListButton=Driver.FindElements ( By.XPath ( "//button[contains (text(), 'Yes')]" ) );
        }
