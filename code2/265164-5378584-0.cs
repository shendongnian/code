    public class Same<T> : ValueInjection
    {
       protected override void Inject(object source, object target)
       {
           var props = typeof (T).GetInfos().ToArray();
           var tp = target.GetInfos().ToArray();
           for (var i = 0; i < props.Count(); i++)
           {
              var prop = props[i];
              for (var j = 0; j < tp.Count(); j++)
              {
                if(prop.Name == tp[j].Name && prop.PropertyType == tp[j].PropertyType)
                tp[j].SetValue(target,prop.GetValue(source, null),null);
              }
            }
          }
      }
