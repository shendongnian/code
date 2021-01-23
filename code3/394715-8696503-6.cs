    public class Matrix3x3 : IAffineTransformCoefficients, ICloneable
    {
        #region Local Variables
        private double [] coeffs;
        private const int _M11 = 0;
        private const int _M12 = 1;
        private const int _M13 = 2;
        private const int _M21 = 3;
        private const int _M22 = 4;
        private const int _M23 = 5;
        private const int _M31 = 6;
        private const int _M32 = 7;
        private const int _M33 = 8;
        #endregion
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x3"/> class.
        /// </summary>
        public Matrix3x3()
        {
            coeffs = new double[9];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x3"/> class.
        /// </summary>
        /// <param name="coefficients">The coefficients to initialise. The number of elements of the array should
        /// be equal to 9, else an exception will be thrown</param>
        public Matrix3x3(double[] coefficients)
        {
            if (coefficients.GetLength(0) != 9)
                throw new Exception("Matrix3x3.Matrix3x3()", "The number of coefficients passed in to the constructor must be 9");
            coeffs = coefficients;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x3"/> class. 
        /// </summary>
        /// <param name="m11">The M11 coefficient</param>
        /// <param name="m12">The M12 coefficien</param>
        /// <param name="m13">The M13 coefficien</param>
        /// <param name="m21">The M21 coefficien</param>
        /// <param name="m22">The M22 coefficien</param>
        /// <param name="m23">The M23 coefficien</param>
        /// <param name="m31">The M31 coefficien</param>
        /// <param name="m32">The M32 coefficien</param>
        /// <param name="m33">The M33 coefficien</param>
        public Matrix3x3(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33)
        {
            // The 3x3 matrix is constructed as follows
            //
            // | M11 M12 M13 | 
            // | M21 M22 M23 | 
            // | M31 M32 M33 | 
            coeffs = new double[] { m11, m12, m13, m21, m22, m23, m31, m32, m33 };
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix3x3"/> class. The IAffineTransformCoefficients
        /// passed in is used to populate coefficients M11, M12, M21, M22, M31, M32. The remaining column (M13, M23, M33)
        /// is populated with homogenous values 0 0 1.
        /// </summary>
        /// <param name="affineMatrix">The IAffineTransformCoefficients used to populate M11, M12, M21, M22, M31, M32</param>
        public Matrix3x3(IAffineTransformCoefficients affineTransform)
        {
            coeffs = new double[] { affineTransform.M11, affineTransform.M12, 0, 
                                    affineTransform.M21, affineTransform.M22, 0, 
                                    affineTransform.OffsetX, affineTransform.OffsetY, 1};
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// Gets or sets the M11 coefficient
        /// </summary>
        /// <value>The M11</value>
        public double M11
        {
            get
            {
                return coeffs[_M11];
            }
            set
            {
                coeffs[_M11] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M12 coefficient
        /// </summary>
        /// <value>The M12</value>
        public double M12
        {
            get
            {
                return coeffs[_M12];
            }
            set
            {
                coeffs[_M12] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M13 coefficient
        /// </summary>
        /// <value>The M13</value>
        public double M13
        {
            get
            {
                return coeffs[_M13];
            }
            set
            {
                coeffs[_M13] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M21 coefficient
        /// </summary>
        /// <value>The M21</value>
        public double M21
        {
            get
            {
                return coeffs[_M21];
            }
            set
            {
                coeffs[_M21] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M22 coefficient
        /// </summary>
        /// <value>The M22</value>
        public double M22
        {
            get
            {
                return coeffs[_M22];
            }
            set
            {
                coeffs[_M22] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M23 coefficient
        /// </summary>
        /// <value>The M23</value>
        public double M23
        {
            get
            {
                return coeffs[_M23];
            }
            set
            {
                coeffs[_M23] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M31 coefficient
        /// </summary>
        /// <value>The M31</value>
        public double M31
        {
            get
            {
                return coeffs[_M31];
            }
            set
            {
                coeffs[_M31] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M32 coefficient
        /// </summary>
        /// <value>The M32</value>
        public double M32
        {
            get
            {
                return coeffs[_M32];
            }
            set
            {
                coeffs[_M32] = value;
            }
        }
        /// <summary>
        /// Gets or sets the M33 coefficient
        /// </summary>
        /// <value>The M33</value>
        public double M33
        {
            get
            {
                return coeffs[_M33];
            }
            set
            {
                coeffs[_M33] = value;
            }
        }
        /// <summary>
        /// Gets the determinant of the matrix
        /// </summary>
        /// <value>The determinant</value>
        public double Determinant
        {
            get
            {
                //                                |a b c|
                // In general, for a 3X3 matrix   |d e f|
                //                                |g h i|
                //
                // The determinant can be found as follows:
                // a(ei-fh) - b(di-fg) + c(dh-eg)
                // Get coeffs
                double a = coeffs[_M11];
                double b = coeffs[_M12];
                double c = coeffs[_M13];
                double d = coeffs[_M21];
                double e = coeffs[_M22];
                double f = coeffs[_M23];
                double g = coeffs[_M31];
                double h = coeffs[_M32];
                double i = coeffs[_M33];
                double ei = e * i;
                double fh = f * h;
                double di = d * i;
                double fg = f * g;
                double dh = d * h;
                double eg = e * g;
                // Compute the determinant
                return (a * (ei - fh)) - (b * (di - fg)) + (c * (dh - eg));
            }
        }
        /// <summary>
        /// Gets a value indicating whether this matrix is singular. If it is singular, it cannot be inverted
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is singular; otherwise, <c>false</c>.
        /// </value>
        public bool IsSingular
        {
            get
            {
                return Determinant == 0;
            }
        }
        /// <summary>
        /// Gets the inverse of this matrix. If the matrix is singular, this method will throw an exception
        /// </summary>
        /// <value>The inverse</value>
        public Matrix3x3 Inverse
        {
            get
            {
                // Taken from http://everything2.com/index.pl?node_id=1271704
                //                                                  a b c
                //In general, the inverse matrix of a 3X3 matrix    d e f
                //                                                  g h i
                //is 
                //        1                              (ei-fh)   (bi-ch)   (bf-ce)
                // -----------------------------   x     (fg-di)   (ai-cg)   (cd-af)
                // a(ei-fh) - b(di-fg) + c(dh-eg)        (dh-eg)   (bg-ah)   (ae-bd)
                // Get coeffs
                double a = coeffs[_M11];
                double b = coeffs[_M12];
                double c = coeffs[_M13];
                double d = coeffs[_M21];
                double e = coeffs[_M22];
                double f = coeffs[_M23];
                double g = coeffs[_M31];
                double h = coeffs[_M32];
                double i = coeffs[_M33];
                //// Compute often used components
                double ei = e * i;
                double fh = f * h;
                double di = d * i;
                double fg = f * g;
                double dh = d * h;
                double eg = e * g;
                double bi = b * i;
                double ch = c * h;
                double ai = a * i;
                double cg = c * g;
                double cd = c * d;
                double bg = b * g;
                double ah = a * h;
                double ae = a * e;
                double bd = b * d;
                double bf = b * f;
                double ce = c * e;
                double cf = c * d;
                double af = a * f;
                // Construct the matrix using these components
                Matrix3x3 tempMat = new Matrix3x3(ei - fh, ch - bi, bf - ce, fg - di, ai - cg, cd - af, dh - eg, bg - ah, ae - bd);
                // Compute the determinant
                double det = Determinant;
                if (det == 0.0)
                {
                    throw new Exception("Matrix3x3.Inverse", "Unable to invert the matrix as it is singular");
                }
                // Scale the matrix by 1/determinant
                tempMat.Scale(1.0 / det);
                return tempMat;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this matrix is affine. This will be true if the right column 
        /// (M13, M23, M33) is 0 0 1
        /// </summary>
        /// <value><c>true</c> if this instance is affine; otherwise, <c>false</c>.</value>
        public bool IsAffine
        {
            get
            {
                return (coeffs[_M13] == 0 && coeffs[_M23] == 0 && coeffs[_M33] == 1);
            }
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Multiplies the current matrix by the 3x3 matrix passed in
        /// </summary>
        /// <param name="rhs"></param>
        public void Multiply(Matrix3x3 rhs)
        {
            // Get coeffs
            double a = coeffs[_M11];
            double b = coeffs[_M12];
            double c = coeffs[_M13];
            double d = coeffs[_M21];
            double e = coeffs[_M22];
            double f = coeffs[_M23];
            double g = coeffs[_M31];
            double h = coeffs[_M32];
            double i = coeffs[_M33];
            double j = rhs.M11;
            double k = rhs.M12;
            double l = rhs.M13;
            double m = rhs.M21;
            double n = rhs.M22;
            double o = rhs.M23;
            double p = rhs.M31;
            double q = rhs.M32;
            double r = rhs.M33;
            // Perform multiplication. Formula taken from
            // http://www.maths.surrey.ac.uk/explore/emmaspages/option1.html
            coeffs[_M11] = a * j + b * m + c * p;
            coeffs[_M12] = a * k + b * n + c * q;
            coeffs[_M13] = a * l + b * o + c * r;
            coeffs[_M21] = d * j + e * m + f * p;
            coeffs[_M22] = d * k + e * n + f * q;
            coeffs[_M23] = d * l + e * o + f * r;
            coeffs[_M31] = g * j + h * m + i * p;
            coeffs[_M32] = g * k + h * n + i * q;
            coeffs[_M33] = g * l + h * o + i * r;
        }
        /// <summary>
        /// Scales the matrix by the specified scalar value
        /// </summary>
        /// <param name="scalar">The scalar.</param>
        public void Scale(double scalar)
        {
            coeffs[0] *= scalar;
            coeffs[1] *= scalar;
            coeffs[2] *= scalar;
            coeffs[3] *= scalar;
            coeffs[4] *= scalar;
            coeffs[5] *= scalar;
            coeffs[6] *= scalar;
            coeffs[7] *= scalar;
            coeffs[8] *= scalar;
        }
        /// <summary>
        /// Makes the matrix an affine matrix by setting the right column (M13, M23, M33) to 0 0 1
        /// </summary>
        public void MakeAffine()
        {
            coeffs[_M13] = 0;
            coeffs[_M23] = 0;
            coeffs[_M33] = 1;
        }
        #endregion
        #region ICloneable Members
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            double[] coeffCopy = (double[])coeffs.Clone();
            return new Matrix3x3(coeffCopy);
        }
        #endregion
        #region IAffineTransformCoefficients Members
        //
        // NB: M11, M12, M21, M22 members of IAffineTransformCoefficients are implemented within the
        // #region Public Properties directive
        //
        /// <summary>
        /// Gets or sets the Translation Offset in the X Direction
        /// </summary>
        /// <value>The M31</value>
        public double OffsetX
        {
            get
            {
                return coeffs[_M31];
            }
            set
            {
                coeffs[_M31] = value;
            }
        }
        /// <summary>
        /// Gets or sets the Translation Offset in the Y Direction
        /// </summary>
        /// <value>The M32</value>
        public double OffsetY
        {
            get
            {
                return coeffs[_M32];
            }
            set
            {
                coeffs[_M32] = value;
            }
        }
        #endregion
    }
