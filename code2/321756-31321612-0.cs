    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace dataCoreLib.Net.Webpage
    {
            public class WebBrowserWithDownloadAbility : WebBrowser
            {
                /// <summary>
                /// The URLMON library contains this function, URLDownloadToFile, which is a way
                /// to download files without user prompts.  The ExecWB( _SAVEAS ) function always
                /// prompts the user, even if _DONTPROMPTUSER parameter is specified, for "internet
                /// security reasons".  This function gets around those reasons.
                /// </summary>
                /// <param name="callerPointer">Pointer to caller object (AX).</param>
                /// <param name="url">String of the URL.</param>
                /// <param name="filePathWithName">String of the destination filename/path.</param>
                /// <param name="reserved">[reserved].</param>
                /// <param name="callBack">A callback function to monitor progress or abort.</param>
                /// <returns>0 for okay.</returns>
                /// source: http://www.pinvoke.net/default.aspx/urlmon/URLDownloadToFile%20.html
                [DllImport("urlmon.dll", CharSet = CharSet.Auto, SetLastError = true)]
                static extern Int32 URLDownloadToFile(
                    [MarshalAs(UnmanagedType.IUnknown)] object callerPointer,
                    [MarshalAs(UnmanagedType.LPWStr)] string url,
                    [MarshalAs(UnmanagedType.LPWStr)] string filePathWithName,
                    Int32 reserved,
                    IntPtr callBack);
                /// <summary>
                /// Download a file from the webpage and save it to the destination without promting the user
                /// </summary>
                /// <param name="url">the url with the file</param>
                /// <param name="destinationFullPathWithName">the absolut full path with the filename as destination</param>
                /// <returns></returns>
                public FileInfo DownloadFile(string url, string destinationFullPathWithName)
                {
                    URLDownloadToFile(null, url, destinationFullPathWithName, 0, IntPtr.Zero);
                    return new FileInfo(destinationFullPathWithName);
                }
            }
        }
