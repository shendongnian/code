    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    namespace StackOverflow
    {
        public enum HelmetState { Null = 1, Empty = 2, HasValue = 3 }
        public enum GarageState { Null = 4, Empty = 5, HasValue = 6 }
        public class ReducingConditionals
        {
            private TrackEventCost trackEventCost = new TrackEventCost();
            private GetHelmets getHelmets = new GetHelmets();
            private GetGarages getGarages = new GetGarages();
            private IDictionary<int, Action> ExecuteCondition;
            //the formvalues collection
            private Hashtable _formvalues;
            public Hashtable formvalues{ get { return _formvalues ?? (_formvalues = new Hashtable()); } }
            //set up dictionary of Actions
            public ReducingConditionals()
            {
                ExecuteCondition = new Dictionary<int, Action>();
                ExecuteCondition[Key(HelmetState.Null, GarageState.Null)] = HelmetsNullGaragesNull;
                ExecuteCondition[Key(HelmetState.Null, GarageState.Empty)] = HelmetsNullGaragesEmpty;
                ExecuteCondition[Key(HelmetState.Null, GarageState.HasValue)] = HelmetsNullGaragesHasValue;
                ExecuteCondition[Key(HelmetState.Empty, GarageState.Null)] = HelmetsEmptyGaragesNull;
                ExecuteCondition[Key(HelmetState.Empty, GarageState.Empty)] = HelmetsEmptyGaragesEmpty;
                ExecuteCondition[Key(HelmetState.Empty, GarageState.Empty)] = HelmetsEmptyGaragesHasValue;
                ExecuteCondition[Key(HelmetState.HasValue, GarageState.Empty)] = HelmetsHasValueGaragesNull;
                ExecuteCondition[Key(HelmetState.HasValue, GarageState.Null)] = HelmetsHasValueGaragesEmpty;
                ExecuteCondition[Key(HelmetState.HasValue, GarageState.HasValue)] = AnyOtherCondition;
            }
            //gets a unique value for each HelmetState/GarageState combination to be used as a key to the dictionary
            private int Key(HelmetState helmetState, GarageState garageState)
            {
                return (int)helmetState + (int)garageState;
            }
            //Execute the appropriate method - n.b. no if statements in sight!
            public void DealWithConditions()
            {
                HelmetState helmetState = GetHelmetState(formvalues["helmets"]);
                GarageState garageState = GetGarageState(formvalues["garages"]);
                ExecuteCondition[Key(helmetState, garageState)]();
            }
            //assign helmet state enum
            private HelmetState GetHelmetState(object helmetValue)
            {
                if (helmetValue == null) return HelmetState.Null;
                if (helmetValue.ToString() == "") return HelmetState.Empty;
                if (Convert.ToInt32(helmetValue) > 0) return HelmetState.HasValue;
                throw new InvalidDataException("Unexpected parameter value");
            }
            //assign garage state enum
            private GarageState GetGarageState(object garageValue)
            {
                if (garageValue == null) return GarageState.Null;
                if (garageValue.ToString() == "") return GarageState.Empty;
                if (Convert.ToInt32(garageValue) > 0) return GarageState.HasValue;
                throw new InvalidDataException("Unexpected parameter value");
            }
            #region encapsulate conditions in methods
            private void AnyOtherCondition()
            {
                ViewBag.hideHelmet = 0;//for jquery , This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 0;//for jquery , This value is passed to jquery script which then decides which field to hide/show
                ViewBag.SelectedHelmets = Convert.ToInt32(formvalues["helmets"]);
                ViewBag.SelectedGarages = Convert.ToInt32(formvalues["garages"]);
                ViewBag.TotalHelmets = Convert.ToInt32(formvalues["helmets"]) * getHelmets.UnitCost;
                ViewBag.TotalGarages = Convert.ToInt32(formvalues["garages"]) * getGarages.UnitCost;
                ViewBag.TotalAmount = ViewBag.TotalHelmets + ViewBag.TotalGarages + trackEventCost.UnitCost;
            }
            private void HelmetsHasValueGaragesNull()
            {
                ViewBag.hideHelmet = 1; //for jquery , This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 0; //for jquery , This value is passed to jquery script which then decides which field to hide/show
                ViewBag.TotalHelmets = Convert.ToInt32(formvalues["helmets"]) * getHelmets.UnitCost;
                ViewBag.TotalAmount = ViewBag.TotalHelmets + trackEventCost.UnitCost;
            }
            private void HelmetsNullGaragesHasValue()
            {
                ViewBag.hideHelmet = 0; //for jquery , This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 1; //for jquery , This value is passed to jquery script which then decides which field to hide/show
                ViewBag.SelectedGarages = Convert.ToInt32(formvalues["garages"]);
                ViewBag.TotalGarages = Convert.ToInt32(formvalues["garages"]) * getGarages.UnitCost;
                ViewBag.TotalAmount = ViewBag.TotalGarages + trackEventCost.UnitCost;
            }
            private void HelmetsNullGaragesNull()
            {
                ViewBag.SelectedHelmets = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.SelectedGarages = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.TotalHelmets = 1;
                ViewBag.TotalGarages = 1;
                ViewBag.hideHelmet = 1;
                ViewBag.hideGarages = 1;
                ViewBag.TotalAmount = trackEventCost.UnitCost;
            }
            private void HelmetsEmptyGaragesNull()
            {
                ViewBag.hideHelmet = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.SelectedHelmets = 1;
                ViewBag.TotalAmount = trackEventCost.UnitCost;
            }
            private void HelmetsNullGaragesEmpty()
            {
                ViewBag.hideHelmet = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.TotalAmount = trackEventCost.UnitCost;
            }
            private void HelmetsHasValueGaragesEmpty()
            {
                ViewBag.hideHelmet = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 0;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.SelectedGarages = 1;
                ViewBag.SelectedHelmets = Convert.ToInt32(formvalues["helmets"]);
                ViewBag.TotalGarages = 1;
                ViewBag.TotalHelmets = Convert.ToInt32(formvalues["helmets"]) * getGarages.UnitCost;
                ViewBag.TotalAmount = ViewBag.TotalHelmets + trackEventCost.UnitCost;
            }
            private void HelmetsEmptyGaragesHasValue()
            {
                ViewBag.hideHelmet = 0;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.SelectedHelmets = 1;
                ViewBag.SelectedGarages = Convert.ToInt32(formvalues["garages"]);
                ViewBag.TotalHelmets = 1;
                ViewBag.TotalGarages = Convert.ToInt32(formvalues["garages"]) * getGarages.UnitCost;
                ViewBag.TotalAmount = ViewBag.TotalGarages + trackEventCost.UnitCost;
            }
            private void HelmetsEmptyGaragesEmpty()
            {
                ViewBag.hideHelmet = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.hideGarages = 1;//for jquery, This value is passed to jquery script which then decides which field to hide/show
                ViewBag.SelectedHelmets = 1;//
                ViewBag.SelectedGarages = 1;//
                ViewBag.TotalHelmets = 1;
                ViewBag.TotalGarages = 1;
                ViewBag.TotalAmount = 1;
                ViewBag.TotalAmount = trackEventCost.UnitCost;
            }
            #endregion
        }
        #region dummy class class implementations
        public class ViewBag
        {
            public static int TotalAmount;
            public static int hideHelmet { get; set; }
            public static int hideGarages { get; set; }
            public static int SelectedHelmets { get; set; }
            public static int SelectedGarages { get; set; }
            public static int TotalGarages { get; set; }
            public static int TotalHelmets { get; set; }
        }
        internal class GetGarages { public int UnitCost; }
        internal class GetHelmets { public int UnitCost; }
        internal class TrackEventCost{ public int UnitCost;}
        #endregion
    }
