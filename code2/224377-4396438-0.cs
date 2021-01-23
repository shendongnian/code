            Type type = typeof(BaseProvider<Int32>);
            foreach (var arg in type.GetGenericArguments())
            {
                MessageBox.Show(arg.FullName);
            }
