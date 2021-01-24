            public void Land(Plane plane){
                _planes.Push(plane);
            }
            public void Land(string reg, int numberOfEngines){
                Plane p = new Plane(numberOfEngines);
                p.Registration = reg;
                _planes.Push(p);
            }
