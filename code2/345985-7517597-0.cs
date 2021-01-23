       //
       // Disable button with no secondary JavaScript function call.
       //
       public static void DisableButtonOnClick(Button ButtonControl)
       {
           DisableButtonOnClick(ButtonControl, string.Empty);
       }
        // Disable button with a JavaScript function call.
        //
        public static void DisableButtonOnClick(Button ButtonControl, string ClientFunction)
        {
            var sb = new StringBuilder(128);
    
            // If the page has ASP.NET validators on it, this code ensures the
            // page validates before continuing.
            sb.Append("if ( typeof( Page_ClientValidate ) == 'function' ) { ");
            sb.Append("if ( ! Page_ClientValidate() ) { return false; } } ");
    
            // Disable this button.
            sb.Append("this.disabled = true;");
    
            // If a secondary JavaScript function has been provided, and if it can be found,
            // call it. Note the name of the JavaScript function to call should be passed without
            // parens.
            if (!String.IsNullOrEmpty(ClientFunction))
            {
                sb.AppendFormat("if ( typeof( {0} ) == 'function' ) {{ {0}() }};", ClientFunction);
            }
    
            // GetPostBackEventReference() obtains a reference to a client-side script function 
            // that causes the server to post back to the page (ie this causes the server-side part 
            // of the "click" to be performed).
            sb.Append(ButtonControl.Page.GetPostBackEventReference(ButtonControl) + ";");
    
            // Add the JavaScript created a code to be executed when the button is clicked.
            ButtonControl.Attributes.Add("onclick", sb.ToString());
        }
