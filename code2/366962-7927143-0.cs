    public class A : DependencyObject
        {
          public string Name { get; set; }
    
          public int speedSimu
          {
            get { return (int)GetValue(speedSimuProperty); }
            set { SetValue(speedSimuProperty, value); }
          }
          public static readonly DependencyProperty speedSimuProperty =
              DependencyProperty.Register("speedSimu", typeof(int), typeof(A), new PropertyMetadata(0));
    
          public int rpmSimu
          {
            get { return (int)GetValue(rpmSimuProperty); }
            set { SetValue(rpmSimuProperty, value); }
          }
          public static readonly DependencyProperty rpmSimuProperty =
              DependencyProperty.Register("rpmSimu", typeof(int), typeof(A), new PropertyMetadata(0));
    
        }
    
        public class B : A
        {
          public int Age { get; set; }
        }
    
        private static void Main(string[] args)
        {
          var assembly = Assembly.GetExecutingAssembly();
          var types = assembly.GetTypes();
    
          var filterTypes = types.Where(t => typeof (DependencyObject).IsAssignableFrom(t)).ToList(); // A and B
    
          Func<string, string> mapFieldToProperty =
            field => field.EndsWith("Property") ? field.Remove(field.IndexOf("Property")) : field;
            
    
          foreach (var type in filterTypes)
          {
            var depFields =
              type.GetFields(BindingFlags.Public | BindingFlags.Static).Where(
                f => typeof (DependencyProperty).IsAssignableFrom(f.FieldType)).ToList(); // speedSimuProperty and rpmSimuProperty
            var depPropertyNames = depFields.ToLookup(f => mapFieldToProperty(f.Name)); 
    
            var depProperties =
              type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(
                prop => depPropertyNames.Contains(prop.Name)).ToList(); // speedSimu and rpmSimu
    
            foreach (var property in depProperties)
            {
              // TODO
            }
    
          }
          return;
        }
