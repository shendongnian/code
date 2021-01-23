    class Dog {
        private Bone myBone;
        public Dog() {
            myBone = new Bone(this);
        }
    }
    
    class Bone {
        private Dog buriedBy;
        public Bone(Dog d) {
            buriedBy = d;
        }
    }
