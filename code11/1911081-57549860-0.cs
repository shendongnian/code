    public class FacAlb : INotifyPropertyChanged
    {
    
    private long idContador;
    public long IdContador 
    {
       set
       {
          if (idContador != value)
          {
             idContador = value;
             OnPropertyChanged("IdContador");
          }
        }
        get
        {
             return idContador;
        }
    }
    
    private long idFacAlb;
    public long IdFacAlb 
    {
       set
       {
          if (idFacAlb != value)
          {
             idFacAlb = value;
             OnPropertyChanged("IdFacAlb");
          }
        }
        get
        {
             return idFacAlb;
        }
    }
    
    privatestring fechaFacAlb;
    public string FechaFacAlb 
    {
       set
       {
          if (fechaFacAlb != value)
          {
             fechaFacAlb = value;
             OnPropertyChanged("FechaFacAlb");
          }
        }
        get
        {
             return fechaFacAlb;
        }
    }
    
    private string TipoDocumento;
    public string tipoDocumento 
    {
       set
       {
          if (tipoDocumento != value)
          {
             tipoDocumento = value;
             NotifyPropertyChanged("TipoDocumento");
          }
        }
        get
        {
             return tipoDocumento;
        }
    }
    
    private string artFacAlb;
    public string ArtFacAlb 
    {
       set
       {
          if (artFacAlb != value)
          {
             artFacAlb = value;
             NotifyPropertyChanged("ArtFacAlb");
          }
        }
        get
        {
             return artFacAlb;
        }
    }
    //... other code
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    //... other code
    
    }
