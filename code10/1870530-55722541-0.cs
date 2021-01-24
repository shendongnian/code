    private static void DataReceivedHandler(
                         object sender,
                         SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
            Session["RfidCurrent"] = indata;
            Debug.WriteLine(indata); //  TAG ID: 03 0e 03 06 (output example and want to pass this data to view)
        }
         
        [HttpGet] 
        public ActionResult Index()
        {
            ViewBag.TagId = Session["RfidCurrent"]
            return View();
        }
