            if (targetHelper != null)
            {
                if (targetHelper.TargetObject is Setter)
                {
                    targetProperty = (targetHelper.TargetObject as Setter).Property;
                }
            }
            if (targetProperty == null)
            {
                targetProperty = targetHelper.TargetProperty as DependencyProperty;
            }
