        class MyCommand
        {
                public double Price { get; set; }
                public string Name { get; set; }
                public ListView List { get; set; } //here is the list you want to add item to.
                public void Handle (object sender, EventArgs e)
                {
                        //Do your staff here
                }
        }
