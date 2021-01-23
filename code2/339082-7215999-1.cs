    public static readonly DependencyProperty EntradaProperty = 
            DependencyProperty.Register("Entrada", typeof(Entradas), typeof(TableroUserControl), new FrameworkPropertyMetadata((d,e)=> { ((TableroUserControl)d).EntradaPropertyChanged(e); }));
    private EntradaPropertyChanged(DependencyPropertyChangedEventArgs e){
      Entradas entrada=(Entradas)e.NewValue ;
      if(entrada=Entradas.Entero)
         // Show your control 
      }else{
         // Hide your control
      }
    }
