     var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
                DisplayAlert("Alert", "You clicked on head", "OK");
            };
            topView.GestureRecognizers.Add(tapGestureRecognizer);
            var tapGestureRecognizer_button = new TapGestureRecognizer();
            tapGestureRecognizer_button.Tapped += (s, e) => {
                // handle the tap
                DisplayAlert("Alert", "You clicked on tail", "OK");
            };
            bottonView.GestureRecognizers.Add(tapGestureRecognizer_button);
