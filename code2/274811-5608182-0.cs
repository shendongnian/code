                            if (pinf.PropertyType.IsGenericType)
                        {
                            MethodInfo method =
                                assetData.GetType().GetMethod("Cast").GetGenericMethodDefinition().MakeGenericMethod(
                                    assetData.AssetType);
                            dynamic castedAsset = method.Invoke(assetData, null);
                            pinf.SetValue(comp, castedAsset, null);
                        }
