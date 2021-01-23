    Root = new RootElement("First Section") {
        new Section ("Test"){
            new StyledStringElement("Login", delegate { Account(); })
            {
                BackgroundColor = UIColor.Green
            }
        }
    }
