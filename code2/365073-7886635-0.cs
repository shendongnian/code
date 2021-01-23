        void MyFunction()
        {
            stringBuilder.Append(((CD)delegate
            {
                switch (whatever)
                {
                    case 1:
                        return "A";
                        ...
                    default:
                        return "X";
                }
            }).Invoke());
        }  
