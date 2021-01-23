public class Stuff
{
     public delegate void DownloadComplete("you can pass whatever info you like here");
     public event DownloadComplete OnDownloadComplete;
     public void GetHtml(string UrlToDownload)
     {
         //Download the data here
         //After data download complete
         if(OnDownloadComplete)
            OnDownloadComplete("arguments to be passed");
     }
}
public class Other
{
     public Other()
     {
        Stuff myStuff=new Stuff();
        myStuff.OnDownloadComplete+=new EventHandler(myStuff_OnDownloadComplete);
     }
     
     void myStuff_OnDownloadComplete("arguments will be passed here")
     {
        //Do your stuff
     }
}
</pre>
