        public class StadiumBaseClass : IBaseball, IBasketball, IHockey, IFootball, ISoccer
        {
            #region IBaseball Members
            public virtual bool IBaseballImplemented
            {
                get
                {
                    return false;
                }
            }
            void IBaseball.Whatever()
            {
                // Do something
            }
            #endregion
            #region IBasketball Members
            public virtual bool IBasketballImplemented
            {
                get
                {
                    return false;
                }
            }
            void IBasketball.Whatever()
            {
                // Do something
            }
            #endregion
            #region IHockey Members
            public virtual bool IHockeyImplemented
            {
                get
                {
                    return false;
                }
            }
            void IHockey.Whatever()
            {
                // Do something
            }
            #endregion
            #region IFootball Members
            public virtual bool IFootballImplemented
            {
                get
                {
                    return false;
                }
            }
            void IFootball.Whatever()
            {
                // Do something
            }
            #endregion
            #region ISoccer Members
            public virtual bool ISoccerImplemented
            {
                get
                {
                    return false;
                }
            }
            void ISoccer.Whatever()
            {
                // Do something
            }
            #endregion
        }
