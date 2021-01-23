    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Pages
    {
        /// <summary>
        /// Page to keep the session alive
        /// </summary>
        public partial class KeepAlive : System.Web.UI.Page
        {
            //- EVENTS ------------------------------------------------------------------------------------------------------------------
    
            #region Events
    
            /// <summary>
            /// Page Load
            /// </summary>
            /// <param name="sender">object</param>
            /// <param name="e">args</param>
            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                    //Add refresh header to refresh the page 60 seconds before session timeout
                    Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) - 60));
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            #endregion Events
    
            //---------------------------------------------------------------------------------------------------------------------------
        }
    }
