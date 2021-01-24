    public Drawable GetDrawableFromAttrRes(int attrRes, Context context)
    {
        TypedArray a = context.ObtainStyledAttributes(new int[] { attrRes });
        try
        {
            return a.GetDrawable(0);
        }
        finally
        {
            a.Recycle();
        }
    }
