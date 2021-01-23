    using System.IO;
    using System.Net;
    using System.Windows;
    using System.Windows.Navigation;
     
    namespace PDFView {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private const string hostUri = "http://localhost:8088/PsuedoWebHost/";
     
            private HttpListener _httpListener;
     
            public MainWindow() {
                InitializeComponent();
     
                this.Loaded += OnLoaded;
            }
     
            /// <summary>
            /// Loads the specified PDF in the WebBrowser control
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="routedEventArgs"></param>
            private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
            {
                // Get the PDF from the 'database'
                byte[] pdfBytes = GetPdfData();
     
                // Create a PDF server that serves the PDF to a browser
                CreatePdfServer(pdfBytes);
     
                // Cleanup after the browser finishes navigating
                Browser.Navigated += BrowserOnNavigated;
                Browser.Navigate(hostUri);
            }
     
            /// <summary>
            /// Retrieve a byte array from a 'database record'
            /// </summary>
            /// <returns></returns>
            private byte[] GetPdfData() {
                // TODO: Replace this code with data access code
                // TODO: Pick a file from the file system for this demo.
                string path = @"c:\Users\Me\Documents\MyPDFDocument.pdf"; 
                byte[] pdfBytes = File.ReadAllBytes(path);
     
                // Return the raw data
                return pdfBytes;
            }
     
            /// <summary>
            /// Creates an HTTP server that will return the PDF  
            /// </summary>
            /// <param name="pdfBytes"></param>
            private void CreatePdfServer(byte[] pdfBytes) {
                _httpListener = new HttpListener();
                _httpListener.Prefixes.Add(hostUri);
                _httpListener.Start();
                _httpListener.BeginGetContext((ar) => {
                                                      HttpListenerContext context = _httpListener.EndGetContext(ar);
     
                                                      // Obtain a response object.
                                                      HttpListenerResponse response = context.Response;
                                                      response.StatusCode = (int)HttpStatusCode.OK;
                                                      response.ContentType = "application/pdf";
     
                                                      // Construct a response.
                                                      if (pdfBytes != null) {
                                                          response.ContentLength64 = pdfBytes.Length;
     
                                                          // Get a response stream and write the PDF to it.
                                                          Stream oStream = response.OutputStream;
                                                          oStream.Write(pdfBytes, 0, pdfBytes.Length);
                                                          oStream.Flush();
                                                      }
     
                                                      response.Close();
                                                  }, null);
     
            }
     
            /// <summary>
            /// Stops the http listener after the browser has finished loading the document
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="navigationEventArgs"></param>
            private void BrowserOnNavigated(object sender, NavigationEventArgs navigationEventArgs)
            {
                _httpListener.Stop();
                Browser.Navigated -= BrowserOnNavigated;
            }
     
        }
    }
