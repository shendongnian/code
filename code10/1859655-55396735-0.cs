        // Versions of Exchange starting with major version 15 and ending with Exchange Server 2013 build 15.0.775.09
        // returned a different query string fragment. This optional check is not required for applications that
        // target Exchange Online.
        if ((serverInfo.MajorVersion == 15) &amp;&amp; (serverInfo.MajorBuildNumber &lt; 775) &amp;&amp;(serverInfo.MinorBuildNumber &lt; 09))
        {
          // If your client is connected to an Exchange 2013 server that has not been updated to CU3,
          // this query string will be returned.
          owaReadFormQueryString = string.Format("#viewmodel=_y.$Ep&amp;ItemID={0}",
            System.Web.HttpUtility.UrlEncode(ewsIdentifer, Encoding.UTF8));
        }
        else
        {
          // If your client is connected to an Exchanger 2010, Exchange 2013 CU3, or Exchange Online server,
          // the WebClientReadFormQueryString is used.
          owaReadFormQueryString = msg.WebClientReadFormQueryString;
        }
        // Create the URL that Outlook Web App uses to open the email message.
        Uri url = service.Url;
        string owaReadAccessUrl = string.Format("{0}://{1}/owa/{2}",
          url.Scheme, url.Host, owaReadFormQueryString);
        if (!string.IsNullOrEmpty(owaReadAccessUrl))
        {
          System.Diagnostics.Process.Start("IEXPLORE.EXE", owaReadAccessUrl);
        }
