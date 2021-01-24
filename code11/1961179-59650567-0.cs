Text="{Binding BezText, UpdateSourceTrigger=PropertyChanged}">
Of course I don't know your exact situation, but I don't think it is necessary to use ICommand and System.Windows.Interactivity even in a MVVM sense. You might consider the following:
ViewModel
        public string LiefText
        {
            get
            {
                return _liefText;
            }
            set
            {
                _liefText = value;
                OnPropertyChanged("LiefText");
                if (!String.IsNullOrWhiteSpace(_liefText))
                    BezEnabled = false;
                else
                    BezEnabled = true;
            }
        }
        public string BezText
        {
            get
            {
                return _bezText;
            }
            set
            {
                _bezText = value;
                OnPropertyChanged("BezText");
                if (!String.IsNullOrWhiteSpace(_bezText))
                    LiefEnabled = false;
                else
                    LiefEnabled = true;
            }
        }
View
        <TextBox Name="txtArtikelbezeichnung" 
             Width="Auto" 
             Margin="20, 0, 20, 0"
             IsEnabled="{Binding BezEnabled}"
             Text="{Binding BezText, UpdateSourceTrigger=PropertyChanged}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="KeyUp">
                    <i:InvokeCommandAction Command="{Binding KeyUpBez}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </TextBox>
       <TextBox Name="txtLieferant" 
             Width="Auto" 
             Margin="20, 0, 20, 0"
             IsEnabled="{Binding LiefEnabled}"
             Text="{Binding LiefText, UpdateSourceTrigger=PropertyChanged}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="KeyUp">
                    <i:InvokeCommandAction Command="{Binding KeyUpLief}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </TextBox>
