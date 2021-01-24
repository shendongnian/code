    public class Password {
        public static string letterhead
        {
            get
            {
                string value = letterhead.phpClass.letterheadres; // Make a copy which you will return
                // Write your clearing procedure here
                // letterhead.phpClass.letterheadres = null;
                return value;
            }
        }
    }
    // You can get the value from other class as
    string value = Password.letterhead; // If there is a value, You will get it and it will be cleared automatically due to the getter.
