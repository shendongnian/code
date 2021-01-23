    var text = "8798dsfgsd98gs87£%"%001912.43.36.";
    var numText = new StringBuilder();
    for(int i = 0; i < text.Length; i++) {
        char c = text[i];
        if ( char.IsDigit(c) ) {
            numText.Append(c);
        }
    }
