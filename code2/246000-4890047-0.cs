        class KeyInfo : IEquatable<KeyInfo>
        {
            public bool Ctrl { get; private set; }
            public bool Shift { get; private set; }
            public bool Alt { get; private set; }
            public bool CapsLock { get; private set; }
            public bool NumLock { get; private set; }
            public bool ScrollLock { get; private set; }
            public Keys Key { get; private set; }
            public KeyInfo(bool ctrl, bool shift, bool alt, bool capsLock, bool numLock, bool scrollLock, Keys key)
            {
                this.Ctrl = ctrl;
                this.Shift = shift;
                this.Alt = alt;
                this.CapsLock = capsLock;
                this.NumLock = numLock;
                this.ScrollLock = scrollLock;
                this.Key = key;
            }
            public override bool Equals(object obj)
            {
                return this.Equals(obj as KeyInfo);
            }
            public bool Equals(KeyInfo other)
            {
                if (other == null)
                    return false;
                return this.Ctrl == other.Ctrl && this.Shift == other.Shift &&
                       this.Alt == other.Alt && this.CapsLock == other.CapsLock &&
                       this.NumLock == other.NumLock && this.ScrollLock == other.ScrollLock &&
                       this.Key == other.Key;
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + this.Ctrl.GetHashCode();
                    hash = hash * 23 + this.Shift.GetHashCode();
                    hash = hash * 23 + this.Alt.GetHashCode();
                    hash = hash * 23 + this.CapsLock.GetHashCode();
                    hash = hash * 23 + this.NumLock.GetHashCode();
                    hash = hash * 23 + this.ScrollLock.GetHashCode();
                    hash = hash * 23 + this.Key.GetHashCode();
                    return hash;
                }
            }
        }
