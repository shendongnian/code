<map:Map 
   Height="628" 
   CredentialsProvider="{StaticResource Key}"
   Center="{Binding MapCenter, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"
   ZoomLevel="{Binding MapZoomLevel, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"
   Mode="Road"
   Name="WorldMap"
>
</map:Map>
In the ViewModel's C# file
Because I was using Prism, by assembly references were
    using System;
    using System.Data;
    using System.IO;
    using Prism.Events;
    using Prism.Commands;
    using Microsoft.Maps.MapControl.WPF;   
    using Microsoft.Maps.MapControl.WPF.Core; 
I added some members to the class member list
        private Double                                  m_Double_ZoomLevel = 6.0;
        private String                                  m_String_MapCenter = null;
        private const Int32                             m_c_Int32_ZoomLevel_Minimum = 1;
        private const Int32                             m_c_Int32_ZoomLevel_Maximum = 20;
I added to the class constructor code to set the map center and zoom level to previously saved values (or default values if no saved ones are available)
            m_String_MapCenter = SavedMapCenter( );
            if( String.IsNullOrWhiteSpace( m_String_MapCenter))
            {
                m_String_MapCenter = "51.5,0";
            }
            m_Double_ZoomLevel = SavedZoomLevel( );
            if( ( m_Double_ZoomLevel < m_c_Int32_ZoomLevel_Minimum) || ( m_Double_ZoomLevel > m_c_Int32_ZoomLevel_Maximum))
            {
                m_Double_ZoomLevel = 6;
            }
I also added to the constructor a couple of Prism delegate commands to manipulate the ZoomLevel programatically
            CommandZoomOut = new DelegateCommand( ZoomOut);
            CommandZoomIn = new DelegateCommand( ZoomIn);
I added to the class a MapZoomLevel Property
        public Double MapZoomLevel
        { 
            get
            {
                return m_Double_ZoomLevel; 
            }
            set
            {
                
                if
                (
                    ( ( Double)( value) >= m_c_Int32_ZoomLevel_Minimum)
                &&  ( ( Double)( value) <= m_c_Int32_ZoomLevel_Maximum)
                &&  ( m_Double_ZoomLevel != ( Double)( value))
                )
                {
                    m_Double_ZoomLevel = ( Double)( value);
                    RaisePropertyChanged( "MapZoomLevel");//NOTE this is a Prism event 
                }
            }
    
I added to the class a MapCenter Property
        public String MapCenter
        {
            get 
            { 
                return m_String_MapCenter; 
            }
            
            set 
            { 
                if( m_String_MapCenter != ( String)( value))
                {
                    m_String_MapCenter = ( String)( value);
                    RaisePropertyChanged( "MapCenter");//NOTE this is a Prism event
                }
            }
        }
I defined the ZoomIn and ZoomOut commands as per the Prism DelegateCommand definition
        public DelegateCommand CommandZoomOut
        { 
            get; 
            set;
        }//public DelegateCommand CommandViewNineTrackTapes
           
        public DelegateCommand CommandZoomIn
        { 
            get; 
            set;
        }//public DelegateCommand CommandZoomIn
        
        private void ZoomOut( )
        {
            if( ZoomLevel > m_c_Int32_ZoomLevel_Minimum)
            {
                ZoomLevel = ZoomLevel - 1;
                SaveZoomLevel( ZoomLevel);
            }
        }
        private void ZoomIn( )
        {
            if( ZoomLevel < m_c_Int32_ZoomLevel_Maximum)
            {
                ZoomLevel = ZoomLevel + 1;
                SaveZoomLevel( ZoomLevel);
            }
        }
And that was it.
