      class MainApp
      {
         /// <summary>
         /// Entry point into console application.
         /// </summary>
         static void Main()
         {
            // An array of creators
            ViewBagCreator creator = new ConcreteCreatorForViewBagObject();
            string garages_form_value = ""; // formvalues["garages"];
            string helmets_form_value = ""; // formvalues["helments"];
            // create viewpage
            ViewBagObject view_bag = creator.FactoryMethod(helmets_form_value,
               garages_form_value, 10, 100, 23);
            Console.WriteLine("Created {0}",
              view_bag.GetType().Name);
            // Assign your viewbag object here
            // ViewBag = view_bag;
            // Wait for user
            Console.ReadKey();
         }
      }
      /// <summary>
      /// The 'ViewBagObject' abstract class
      /// </summary>
      abstract class ViewBagObject
      {
         public int hideHelmet;
         public int hideGarages;
         public int SelectedHelmets;
         public int SelectedGarages;
         public int TotalHelmets;
         public int TotalGarages;
         public int TotalAmount;
      }
      /// <summary>
      /// A 'ViewBagNoSelection' class
      /// </summary>
      class ViewBagNoSelection : ViewBagObject
      {
         public ViewBagNoSelection(int trackEventUnitCost)
         {
            hideHelmet = 1;
            hideGarages = 1;
            SelectedHelmets = 1;
            SelectedGarages = 1;
            TotalHelmets = 1;
            TotalGarages = 1;
            TotalAmount = trackEventUnitCost;
         }
      }
      /// <summary>
      /// A 'ViewBagGaragesNoHelments' class
      /// </summary>
      class ViewBagGaragesNoHelments : ViewBagObject
      {
         public ViewBagGaragesNoHelments(int garagesValue, int garagesUnitCost, int trackEventUnitCost)
         {
            hideHelmet = 0;
            hideGarages = 1;
            SelectedHelmets = 1;
            SelectedGarages = garagesValue;
            TotalHelmets = 1;
            TotalGarages = garagesValue * garagesUnitCost;
            TotalAmount = TotalGarages * trackEventUnitCost;
         }
      }
      /// <summary>
      /// A 'ViewBagHelmentsNoGarages' class
      /// </summary>
      class ViewBagHelmentsNoGarages : ViewBagObject
      {
         public ViewBagHelmentsNoGarages(int helmetsValue, int helmentsUnitCost, int trackEventUnitCost)
         {
            hideHelmet = 0;
            hideGarages = 1;
            SelectedHelmets = helmetsValue;
            SelectedGarages = 1;
            TotalHelmets = helmetsValue * helmentsUnitCost;
            TotalGarages = 1;
            TotalAmount = TotalHelmets * trackEventUnitCost;
         }
      }
      /// <summary>
      /// The 'ViewBagCreator' abstract class
      /// </summary>
      abstract class ViewBagCreator
      {
         public abstract ViewBagObject FactoryMethod(
            string helmetsFormValue, string garagesFormValue,
            int helmetsUnitCost, int garagesUnitCost, int trackEventUnitCost);
      }
      /// <summary>
      /// A 'ConcreteCreator' class
      /// </summary>
      class ConcreteCreatorForViewBagObject : ViewBagCreator
      {
         public override ViewBagObject FactoryMethod(
            string helmetsFormValue, string garagesFormValue,
            int helmetsUnitCost, int garagesUnitCost, int trackEventUnitCost)
         {
            bool helmets_value_is_null = (helmetsFormValue == null);
            bool helmets_value_is_empty = (helmetsFormValue == "");
            bool garages_value_is_null = (garagesFormValue == null);
            bool garages_value_is_empty = (garagesFormValue == "");
            
            int helmets = 0;
            int garages = 0;
            int.TryParse(garagesFormValue, out garages);
            int.TryParse(helmetsFormValue, out helmets);
            bool garages_greater_than_zero = garages > 0;
            bool helmets_greater_than_zero = helmets > 0;
            if (helmets_value_is_empty && garages_value_is_empty)
            {
               return new ViewBagNoSelection(trackEventUnitCost);
            }
            else if (helmets_value_is_empty && garages_greater_than_zero)
            {
               return new ViewBagGaragesNoHelments(garages, garagesUnitCost, trackEventUnitCost);
            }
            else if (garages_value_is_empty && helmets_greater_than_zero)
            {
               return new ViewBagHelmentsNoGarages(helmets, helmetsUnitCost, trackEventUnitCost);
            }
            //...
            return null;
         }
      }
