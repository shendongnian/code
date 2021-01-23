    public ActionResult Survey(SurveyCollection surveyCollection)
            {
                if (surveyCollection != null)
                {
                    Answer_DropDownCordinateOptionList traceObject = new Answer_DropDownCordinateOptionList();
                    IList<Answer_DropDownCordinateOptionList> traceObjectCollection = new List<Answer_DropDownCordinateOptionList>();
                    traceObjectCollection = ExtractNestedObjects<Answer_DropDownCordinateOptionList>(surveyCollection, traceObject, traceObjectCollection);
                }
    
                return View(surveyCollection);
            }
    
            private static IList<T> ExtractNestedObjects<T>(object baseObject, T findObject, IList<T> resultCollection)
            {
                if (baseObject != null && findObject != null)
                {
                    Type typeDestination = findObject.GetType();
    
                    Type typeSource = baseObject.GetType();
                    PropertyInfo[] propertyInfoCollection = typeSource.GetProperties();
                    foreach (PropertyInfo propertyInfo in propertyInfoCollection)
                    {
                        if (propertyInfo.PropertyType.FindInterfaces((t, c) => t == typeof(IEnumerable), null).Length > 0)
                        {
                            if(propertyInfo.GetValue(baseObject, null) != null)
                            {
                                if(propertyInfo.GetValue(baseObject, null).GetType().IsPrimitive)
                                {
                                    ExtractNestedObjects<T>(propertyInfo.GetValue(baseObject, null), findObject, resultCollection);
                                }
                                else if (propertyInfo.GetValue(baseObject, null).GetType().IsGenericType)
                                {
                                    foreach (var item in (IList)propertyInfo.GetValue(baseObject, null))
                                    {
                                        ExtractNestedObjects<T>(item, findObject, resultCollection);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (propertyInfo.Name == typeDestination.Name)
                            {
                                if (propertyInfo.GetValue(baseObject, null) != null)
                                {
                                    resultCollection.Add((T)propertyInfo.GetValue(baseObject, null));
                                }
                            }
    
                            ExtractNestedObjects<T>(propertyInfo.GetValue(baseObject, null), findObject, resultCollection);
                        }
                    }
                }
                return resultCollection;
            }
