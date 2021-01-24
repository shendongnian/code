    public void ChangePlayerMaterial( string playerColor )
    {
        PropertyInfo propertyInfo = typeof(Color).GetProperty( playerColor.ToLower() );
        if( propertyInfo != null )
        {
            Color color = (Color) propertyInfo.GetValue(null, null);
            PlayerMat.color = color ;
        }
        else
        {
            Debug.LogError("The color " + playerColor + " does not exist");
        }
    }
