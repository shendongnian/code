            _List = _List.FindAll(
                delegate(MyEntity entity)
                {
                    return entity.Title.Contains(TXT_Title.Text);
                }
            );
            Gview.DataSource = _List  ;
