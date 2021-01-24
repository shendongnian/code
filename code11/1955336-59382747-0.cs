    foreach (var Object in ThingsToActivate)
    {
          var prop = Object.GetComponent<foo>().GetType().GetPropery("Active");
          if(prop != null && prop.PropertyType == typeof(bool)
              prop.SetValue(Object.GetComponent<foo>(), true);
    }
