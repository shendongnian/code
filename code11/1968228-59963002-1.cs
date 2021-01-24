    class MyControlBuilder
    {
        public Control Build(FieldType fieldType)
        {
            switch (fieldType)
            {
                case FieldType.Text:
                    return new TextBox();
                case FieldType.Image:
                    return new PictureBox();
                case FieldType.ProgressBar:
                    return new ProgressBar();
                case FieldType.Group:
                    return new GroupBox();
                default:
                    throw new NotImplementedException();
            }
        }
    }
