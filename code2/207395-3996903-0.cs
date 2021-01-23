            lista = lista.Where(Expression.Lambda<Func<Pessoa, bool>>(
                Expression.Equal(
                    propriedade,
                    Expression.Constant(Convert.ChangeType(textBox3.Text, propType.PropertyType))
                    ), param));
