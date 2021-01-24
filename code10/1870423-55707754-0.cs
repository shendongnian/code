public string Text {
            get {
                return text;
            } set {
                text = value;
                if (text.Equals("12345"))
                {
                    EndTestExitAction(window)
                }
            }
        }
where `window` is a property of your View Model.
