            public class MySubclass : Control
            {
                protected override OnClick( EventArgs e )
                {
                    if( !this.Disabled )
                    {
                        base.OnClick( e );
                    } 
                }
                public Boolean Disabled { get; set; }
            }
