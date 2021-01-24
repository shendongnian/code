            var builder = new MyControlBuilder();
            var control = builder.Build(FieldType.ProgressBar);
            if(control is ProgressBar progressBar)
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
            }
