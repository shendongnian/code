        class Move {
            public Move(string piece, string axis, string direction) {
                Piece = piece;
                Axis = axis;
                Direction = direction;
            }
            string Piece { get; private set; }
            string Axis { get; private set; }
            string Direction { get; private set; }
            public override Equals(object obj) {
                Move other = obj as Move;
                if ( other != null ) 
                    return Piece == other.Piece && 
                           Axis == other.Axis && 
                           Direction == other.Direction;
                return false;
            }
            public override GetHashCode() {
                return Piece.GetHashCode() ^ 
                       Axis.GetHashCode() ^ 
                       Direction.GetHashCode();
            }
            // TODO: override ToString() as well
        }
