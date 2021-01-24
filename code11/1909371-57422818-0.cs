    public class Webcam : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int idWebcam { get; set; }
        public string c_mpr { get; set; }
        public int c_tel { get; set; }
        public string c_uuid { get; set; }
        public string direzione { get; set; }
        public string frame1 { get; set; }
        public string frame2 { get; set; }
        public string frame3 { get; set; }
        public string frame4 { get; set; }
    
        public double n_crd_lat { get; set; }
        public double n_crd_lon { get; set; }
        public int n_ind_pri { get; set; }
        public double n_prg_km { get; set; }
        public int ramo { get; set; }
        public int str { get; set; }
        public string strada { get; set; }
        public string t_str_vid { get; set; }
        public string thumb { get; set; }
        
        // modified code
        ImageSource image1 ;
        
        public ImageSource Image1
            {
                set
                {
                    if (image1 != value)
                    {
                        image1 = value;
                        OnPropertyChanged("Image1");
                    }
                }
                get
                {
                    return image1 ;
                }
            }
    
        ImageSource image2 ;
        
        public ImageSource Image2
            {
                set
                {
                    if (image2 != value)
                    {
                        image2 = value;
                        OnPropertyChanged("Image2");
                    }
                }
                get
                {
                    return image2 ;
                }
            }
    
        ImageSource image3 ;
        
        public ImageSource Image3
            {
                set
                {
                    if (image3 != value)
                    {
                        image3 = value;
                        OnPropertyChanged("Image3");
                    }
                }
                get
                {
                    return image3 ;
                }
            }
    
        ImageSource image4 ;
        
        public ImageSource Image4
            {
                set
                {
                    if (image4 != value)
                    {
                        image4 = value;
                        OnPropertyChanged("Image4");
                    }
                }
                get
                {
                    return image4 ;
                }
            }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
