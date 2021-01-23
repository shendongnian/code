    namespace UI
    {
        public partial class MiniTrafficLight : UserControl
        {
            private static PropertyMetaData trafficLightStateMetaData = new PropertyMetaData(new PropertyChangedCallBack(TrafficLightState_Changed));
            public static readonly DependencyProperty TrafficLightStateProperty = DependencyProperty.Register("TrafficLightState", typeof(TrafficLightState), typeof(MiniTrafficLight), trafficLightStateMetaData);
    
            public TrafficLightState TrafficLightState
            {
                get { return (TrafficLightState)this.GetValue(TrafficLightStateProperty); }
                set { this.SetValue(TrafficLightStateProperty, value); }
            }
            private static void TrafficLightState_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MiniTrafficLight sender = d as MiniTrafficLight;
                TrafficLightState state = (TrafficLightState)e.NewState;
                if( state == TrafficLightState.Red )
                {
                    //...
                }
                else if ( state == TrafficLightState.Yellow )
                {
                    //...
                }
                else
                {
                    //...
                }
            }
        }
    }
