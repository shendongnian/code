    class Human {
      public enum SexType { Unknown, Male, Female };
      public Human() {
        HairColor = Color.Brown;
        Sex = SexType.Unknown;
      }
      public bool IsAdam { get { return true; } }
      public Color HairColor { get; set; }
      public SexType Sex { get; set; }
      public virtual string Talk() {
        switch (Sex) {
          case SexType.Male:
            return "I am a Male.";
          case SexType.Female:
            return "I am a Female.";
          default:
            return "I am a human.";
        }
      }
    }
    class Male : Human {
      public Male() {
        Sex = SexType.Male;
      }
    }
    class Female : Human {
      public Female() {
        Sex = SexType.Female;
      }
    }
    class Child : Human {
      public Child() {
      }
      public override string Talk() {
        switch (Sex) {
         case SexType.Male:
           return "I am a boy.";
         case SexType.Female:
           return "I am a girl.";
         default:
           return "I am a child.";
        }
      }
    }
