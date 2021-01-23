    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Facebook;
    
    namespace FacebookSampleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Get an access token in some manner.
                // By default you can only get public info.
                string token = null;
    
                Facebook.FacebookAPI api = new Facebook.FacebookAPI(token);
    
                var parameters = new Dictionary
                {
                   { "message",  'Wow, I love Google!' },
                   { "name" ,  'Google' },
                   { "description" ,  'Description of post' },
                   { "picture", 'http://www.google.com/logo.png' },
                   { "caption" ,  'This is google.com' },
                   { "link" ,  'http://www.google.com' },
                   { "type" , "link" }
                };
    
                JSONObject wallPost = api.MakeRequest("/[PAGE_ID]/feed", 'POST', parameters);
    
            }
          }
        }
