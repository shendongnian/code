       //in the Pay class
       public override bool Equals(Object o) {
          Pay pay = o as Pay;
          if (pay == null) return false;
          // you haven't said if Number should be included in the comparation
          return EventId == pay.EventId; // && Number == pay.Number; (if applies)
       }
