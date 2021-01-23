        //-----------------------------------------------------------------------------
        // <copyright file="ObservableObject.cs" company="DCOM Productions">
        //     Copyright (c) DCOM Productions.  All rights reserved.
        // </copyright>
        //-----------------------------------------------------------------------------
        namespace PropertyChangedEventExample {
            using System;
            public class ObservableObject : Object {
                /// <summary>
                /// Expose the default constructor
                /// </summary>
                public ObservableObject() {
                    // No default implementation
                }
                private object m_Object = null;
                /// <summary>
                /// Base object
                /// </summary>
                public object Object {
                    get {
                        return m_Object;
                    }
                    set {
                        if (m_Object != value) {
                            m_Object = value;
                            OnObjectChanged(this, EventArgs.Empty);
                        }
                    }
                }
                /// <summary>
                /// Triggered when the value of this object has changed.
                /// </summary>
                public event System.EventHandler<EventArgs> ObjectChanged;
                /// <summary>
                /// EventHandler wire-up
                /// </summary>
                protected virtual void OnObjectChanged(object sender, System.EventArgs e) {
                    if (ObjectChanged != null) {
                        ObjectChanged(sender, e);
                    }
                }
                /// <summary>
                /// Gets the value
                /// </summary>
                public object Get() {
                    return this.Object;
                }
                /// <summary>
                /// Sets the value
                /// </summary>
                public void Set(object value) {
                    this.Object = value;
                }
            }
        }
