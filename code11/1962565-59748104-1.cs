        Texture2D screencap;
        Texture2D border;
        bool shot=false;
        public string path;
        
        void Start () {
             screencap=new Texture2D(300,200,TextureFormat.RGB24,false);
             border=new Texture2D(2,2,TextureFormat.ARGB32,false);
             border.Apply();
        }
        
        // Update is called once per frame
        void Update () {
            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                StartCoroutine("Capture");
            }
        
        }
        string fileName(int width, int height)
        {
            return string.Format("screen_{0}x{1}_{2}.png",
                                 width, height,
                                 System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        }
        
        void OnGUI()
        {
            GUI.DrawTexture(new Rect(200,100,300,2),border,ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(200,300,300,2),border,ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(195,100,2,200),border,ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(500,100,2,201),border,ScaleMode.StretchToFill);
        
            if(shot)
            {
                GUI.DrawTexture(new Rect(50,10,60,40),screencap,ScaleMode.StretchToFill);
                //Application.CaptureScreenshot(myFolderLocation+myFilename);
            }
        }
        
        IEnumerator Capture()
        {
            yield return new WaitForEndOfFrame();
            screencap.ReadPixels(new Rect(198,98,298,198),0,0);
            screencap.Apply();
            shot=true;
        
            byte[] bytes=border.EncodeToPNG();
            string filename=fileName(Convert.ToInt32(screencap.width), Convert.ToInt32(screencap.height));
            Application.CaptureScreenshot("D:"+filename);
        }
    
    
