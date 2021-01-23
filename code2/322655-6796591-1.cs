        public class YourCustomControl : CustomControl
        {
           public override void Selection()
           {
              base.Selection(); // first call the original method
              
              // now do some custom stuff
           }
        }
