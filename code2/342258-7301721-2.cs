    static RectangleShape MakeSimpleShape()
    {
        return
            new RectangleShape
                {
                    BoundingBox = new Rect (-200, -200, 400, 400),
                    Pen = s_redPen,
                    Brush = null,
                    Children =
                        new Shape[]
                            {
                                new RectangleShape
                                    {
                                        BoundingBox = new Rect (-40, -40, 40, 40),
                                        Transform = new TranslateTransform (100, 100),
                                    },
                            },
                };
    }
