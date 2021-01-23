    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    
      /// <summary>
            /// loads the colours
            /// </summary>
            private void LoadColours()
            {
                try
                {
                    Color testColor = ProfessionalColors.ButtonCheckedGradientBegin;
                    Type colorType = testColor.GetType();
    
                    PropertyInfo[] propInfoList = colorType.GetProperties( BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public );
    
                    lvColours.Items.Clear();
    
                    foreach ( PropertyInfo oPropertyInfo in propInfoList )
                    {
                        Color color = ( Color ) oPropertyInfo.GetValue( null, null );
    
                        ListViewItem oListViewItem = new ListViewItem( GetColorName( oPropertyInfo.Name ) );
    
                        oListViewItem.BackColor = color;
    
                        lvColours.Items.Add( oListViewItem );
                    }
    
                    Type ProfType = typeof( ProfessionalColors );
    
                    PropertyInfo[] PropInfos = ProfType.GetProperties( BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public );
    
                    foreach ( PropertyInfo oPropertyInfo in PropInfos )
                    {
                        Color oColor =(Color) oPropertyInfo.GetValue( null, null );
    
                        ListViewItem oListViewItem = new ListViewItem( GetColorName( oPropertyInfo.Name ) );
    
                        oListViewItem.BackColor = oColor;
    
                        lvProfessionalColours.Items.Add( oListViewItem );
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( ex.Message );
                }
            }
        /// <summary>
        /// Gets the Color Name
        /// </summary>
        protected string GetColorName( string strFullName )
        {
            string strName = "";
            int idx = strFullName.LastIndexOf( "." );
            if ( idx != -1 )
            {
                strName = strFullName.Substring( idx );
            }
            else
            {
                return strFullName;
            }
            return strName;
        }
