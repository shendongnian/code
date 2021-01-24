    private static Color gridMinorColor
    {
        get
        {
            if (defaultColors)
            {
                return EditorGUIUtility.isProSkin ? kGridMinorColorDark : kGridMinorColorLight;
            }
            
            // equals the else part
            // but since you return within the if you can skip the else keyword
            return EditorGUIUtility.isProSkin ? CustomkGridMinorColorDark : CustomkGridMinorColorLight;
        }
    }
